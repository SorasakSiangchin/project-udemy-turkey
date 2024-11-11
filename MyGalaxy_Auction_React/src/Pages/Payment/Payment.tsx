import { Elements } from '@stripe/react-stripe-js';
import { loadStripe } from '@stripe/stripe-js';
import { useState } from 'react'
import { useLocation } from 'react-router-dom'
import { Loader } from '../../Helper';
import CheckoutForm from './CheckoutForm';
import { Modal } from 'react-bootstrap';

const Payment = () => {
    const { state } = useLocation();
    // ข็อมูลที่ส่งมาทาง path
    const { apiResult } = state;

    const [show, setShow] = useState(true);

    const handleShow = () => setShow(true)
    const handleClose = () => setShow(false)


    // Publishable key
    const stripePromise = loadStripe("pk_test_51PwQHqCnIQpNd3QECMcYApWYURg5wRS3v4ynHfqGVcG0WDEmuRDZFSwVTmDvcLlfWekEETGYeneQKxBn9cLfX3RT00TZ5Ls9cz")
    if (apiResult) {

        const options = {
            // passing the client secret obtained from the server
            clientSecret: apiResult.clientSecret,
        };

        return <>
            <Elements stripe={stripePromise} options={options} >
                <div className='container m5 p-5' >

                    <div className='row' >
                        <Modal show={show} onHide={handleShow}>
                            <div className=' container' >
                                <CheckoutForm />
                            </div>
                        </Modal>
                    </div>
                </div>
            </Elements>
        </>
    }

    else {
        return (
            <Loader />
        )
    }
}

export default Payment