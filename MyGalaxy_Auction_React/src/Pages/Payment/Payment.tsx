import { Elements } from '@stripe/react-stripe-js';
import { loadStripe } from '@stripe/stripe-js';
import { useState } from 'react'
import { useLocation } from 'react-router-dom'
import { Loader } from '../../Helper';
import CheckoutForm from './CheckoutForm';

const Payment = () => {
    const { state } = useLocation();
    // ข็อมูลที่ส่งมาทาง path
    const { apiResult, userStore } = state;

    const [show, setShow] = useState(false);
    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);

    // Publishable key
    const stripePromise = loadStripe("pk_test_51PwQHqCnIQpNd3QECMcYApWYURg5wRS3v4ynHfqGVcG0WDEmuRDZFSwVTmDvcLlfWekEETGYeneQKxBn9cLfX3RT00TZ5Ls9cz")
    if (apiResult) {

        const options = {
            // passing the client secret obtained from the server
            clientSecret: apiResult.clientSecret,
        };

        return <div className="">
            <Elements stripe={stripePromise} options={options} >
                <div className='container m5 p-5' >
                    <div className='row' >
                        <div className=' container' >
                            <CheckoutForm />
                        </div>
                    </div>
                </div>
            </Elements>
        </div>
    }

    else {
        return (
            <Loader />
        )
    }
}

export default Payment