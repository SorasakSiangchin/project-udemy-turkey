import React from 'react'

const CreateBid = () => {
    return (
        <div className='container' >
            <form>
                <label htmlFor='bidAmount' >Bid Amount : </label>
                <input type='number' className='form-control' id='bidAmount' name='bidAmount' />
                <div className='text-center mb-3 ' >
                    <button type='button' onClick={() => { }}  >Place Bid</button>
                </div>
            </form >
        </div >
    )
}

export default CreateBid