/* eslint-disable @typescript-eslint/no-explicit-any */
import React, { useEffect, useState } from 'react'
import { useGetBidByVehicleIdQuery } from '../../Api/bidApi'
import { Loader } from '../../Helper'
import './Styles/bid.css'
import { useCheckStatusAuctionPriceMutation } from '../../Api/paymentHistoryApi'
import { checkStatus } from '../../interfaces/checkStatus'
import { useSelector } from 'react-redux'
import { RootState } from '../../Storage/store'
import userModel from '../../interfaces/userModel'
import CreateBid from './CreateBid'
import { useGetVehicleByIdQuery } from '../../Api/vehicleApi'

const BidsDetail = ({ vehicleId }: { vehicleId: string }) => {

    const { data, isLoading } = useGetBidByVehicleIdQuery(parseInt(vehicleId))
    const userStore: userModel = useSelector((state: RootState) => state.authenticationReducer);

    // [] คือ destructuring assignment ฟังก์ชัน checkStatusAuction นี้สามารถใช้เพื่อเรียก API mutation
    const [checkStatusAuction] = useCheckStatusAuctionPriceMutation()
    const [result, setResultState] = useState();
    const response_data = useGetVehicleByIdQuery(parseInt(vehicleId));

    useEffect(() => {
        const checkModel: checkStatus = {
            userId: userStore.nameid!,
            vehicleId: parseInt(vehicleId)
        }
        checkStatusAuction(checkModel).then((response) => {
            setResultState(response!.data?.isSuccess)

        }).catch((error) => {
            console.error("Error : ", error)
        });

    }, [vehicleId, userStore.nameid, checkStatusAuction])


    if (!data) {
        return <Loader />
    }


    return (
        <>
            {
                result ? (
                    <div className='container mb-5' >
                        <CreateBid />
                    </div>
                ) : (

                    <div className='container mb-5' style={{ display: 'flex', justifyContent: "center" }}  >
                        <button className='btn btn-warning' type='button' onClick={() => { }} >Pay PreAuction Price  ${response_data.currentData?.result.auctionPrice}  </button>
                    </div>
                )
            }

            <div className="bid-list">
                {
                    data.result.map((data: any, index: number) => {
                        return <div key={index}>
                            <div className="mt-4" >
                                <div className="bid">
                                    <div className="bid-number">{data.bidId}</div>
                                    <div className="bid-date">{data.bidDate}</div>
                                    <div className="bid-amount">${data.bidAmount}</div>
                                </div>
                            </div>
                            <br />
                        </div>
                    })
                }
            </div></>
    )
}

export default BidsDetail