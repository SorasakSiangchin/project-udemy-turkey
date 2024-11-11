import { useNavigate, useParams } from "react-router-dom";
import { useGetVehicleByIdQuery } from "../../Api/vehicleApi";
import { useDispatch, useSelector } from "react-redux";
import userModel from "../../interfaces/userModel";
import { RootState } from "../../Storage/store";
import "./Styles/bidCheckout.css"
import { Loader } from "../../Helper";
import { useState } from "react";
import { useDoPaymentMutation } from "../../Api/paymentApi";
import { apiResponse } from "../../interfaces/apiResponse";
import { getOrderInfo } from "../../Storage/Redux/orderSlice";
import { getVehicle } from "../../Storage/Redux/vehicleSlice";

const BidCheckout = () => {
    const { vehicleId } = useParams();
    const { data, isLoading } = useGetVehicleByIdQuery(vehicleId);
    const userStore: userModel = useSelector((state: RootState) => state.authenticationReducer);
    const [initialPayment] = useDoPaymentMutation();
    const Dispatch = useDispatch();
    const Navigate = useNavigate();

    const initialState = {
        name: userStore.fullName,
        email: userStore.email,
        phoneNumber: ""
    }

    const [phone, setPhoneState] = useState(initialState.phoneNumber);
    const [name, setNameState] = useState(initialState.name);
    const [email, setEmailState] = useState(initialState.email);
    const [loading, setLoadingState] = useState<boolean>();

    const handleSubmit = async (e: React.ChangeEvent<HTMLFormElement>) => {
        e.preventDefault();
        setLoadingState(true);

        const { data }: apiResponse = await initialPayment({
            userId: userStore.nameid,
            vehicleId: vehicleId
        })

        if (data) {
            // set the state Order
            // clientSecret => เพื่อยืนยันการชำระเงินโดยใช้ Stripe.js ควรถูกเก็บเป็นความลับและไม่ควรถูกเปิดเผยต่อสาธารณะ 
            // stripePaymentIntentId เพื่อดึงข้อมูลหรืออัปเดตสถานะของ PaymentIntent.
            Dispatch(getOrderInfo({
                vehicleId: data?.result.vehicleId,
                userId: data?.result.userId,
                clientSecret: data?.result.clientSecret,
                stripePaymentIntentId: data?.result.stripePaymentIntentId,
            }))
        }

        if (vehicleId) {
            Dispatch(getVehicle(vehicleId!))

        }

        Navigate("/payment", {
            state: { apiResult: data?.result, userStore }
        });


        setLoadingState(false);
    }

    if (data) {
        return (
            <div className='container' >
                <div className='card text-center' >
                    <form onSubmit={handleSubmit} >
                        <img src={data.result.image} className='card-image' alt="" />
                        <div className='card-content text-center' >
                            <h3 className='card-title' > {data.result.brandAndModel} </h3>
                            <p className='card-text' > <span className='text-black bold' > ${data.result.auctionPrice} </span> </p>
                        </div>
                        <div className='container' >
                            <div className='form-group mt-3' >
                                <span className='text-black' > <strong> Name </strong> </span>
                                <input className="form-control" type="text" placeholder="Default input" defaultValue={name} onChange={(e) => setNameState(e.target.value)} aria-label="default input example"></input>
                            </div>
                            <div className='form-group mt-3' >
                                <span className='text-black' > <strong> Email </strong> </span>
                                <input className="form-control" type="text" placeholder="Default input" defaultValue={email} onChange={(e) => setEmailState(e.target.value)} aria-label="default input example"></input>
                            </div>
                            <div className='form-group mt-3' >
                                <span className='text-black' > <strong> PhoneNumber </strong> </span>
                                <input className="form-control" type="text" placeholder="Default input" defaultValue={phone} onChange={(e) => setPhoneState(e.target.value)} aria-label="default input example"></input>
                            </div>
                        </div>
                        <div className='card-footer' >
                            <button type="submit" className="btn btn-lg btn-success form-control mt-3"  >
                                {
                                    loading ? (<Loader />) : " Pay Auction Price"
                                }

                            </button>
                        </div>
                    </form>
                </div>
            </div>
        )
    }
    else {
        return (
            <Loader />
        )
    }
}

export default BidCheckout