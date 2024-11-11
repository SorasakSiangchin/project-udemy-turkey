import { useStripe, useElements, PaymentElement } from '@stripe/react-stripe-js';
import { useState } from 'react';
import { useSelector } from 'react-redux';
import { useNavigate } from 'react-router-dom';
import { RootState } from '../../Storage/store';

const CheckoutForm = () => {
    const stripe = useStripe();
    const elements = useElements();
    const [isProcessing, setIsProcessing] = useState(false)
    const Navigate = useNavigate()
    const vehicleId: string = useSelector((state: RootState) => state.vehicleReducer.vehicleId)

    const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
        // We don't want to let default form submission happen here,
        // which would refresh the page.
        event.preventDefault();

        if (!stripe || !elements) {
            // Stripe.js hasn't yet loaded.
            // Make sure to disable form submission until Stripe.js has loaded.
            return;
        }

        const result = await stripe.confirmPayment({
            //`Elements` instance that was used to create the Payment Element
            elements,
            confirmParams: {
                return_url: "https://example.com/order/123/complete",
            },
            redirect: 'if_required'
        });

        if (result.error) {
            // Show error to your customer (for example, payment details incomplete)
            setIsProcessing(false);
        }

        if (result.paymentIntent?.status === "succeeded") {
            Navigate(`/Vehicle/BidCheckout/${vehicleId}`)
        }

        setIsProcessing(false);

    };

    return (
        <form onSubmit={handleSubmit}>
            <PaymentElement />
            <button disabled={!stripe || isProcessing} type='submit' className='btn btn-primary' >
                {
                    isProcessing ? 'Processing...' : 'Submit Pay'
                }
            </button>
        </form>
    )
};

export default CheckoutForm;