import React, { useEffect, useState } from 'react'
import { VehicleModel } from '../../interfaces/vehicleModel'
import './Styles/Circle.css'
import formatTime from '../../Utility/formatTime'
const Circle = ({ vehicle }: {
    vehicle: VehicleModel
}) => {

    const [countdown, setCountdown] = useState(calculateCountDown());

    function calculateCountDown() {
        // แปลงให้เป็น มิลลิวินาทีในรูปแบบของ Unix timestamp
        const endTime = new Date(vehicle.endTime).getTime();

        // แปลงเวลาปัจจุบันให้เป็น มิลลิวินาทีในรูปแบบของ Unix timestamp
        const currentTime = new Date().getTime();

        // หาความต่างของเวลาที่เหลือ
        const timeRemaining = endTime - currentTime;

        if (timeRemaining === 0) {
            return 0;
        }

        // หาค่ามากที่สุดระหว่าง 0 และเวลาที่เหลือ
        return Math.max(0, timeRemaining);
    }

    useEffect(() => {
        // เป็นฟังก์ชันใน JavaScript ที่ใช้ในการเรียกใช้ฟังก์ชันหรือโค้ดบางอย่างซ้ำๆ ในช่วงเวลาที่กำหนด (เป็นมิลลิวินาที)
        const interval = setInterval(() => {
            setCountdown(calculateCountDown());
            if (countdown === 0) {
                // ใช้ในการหยุดการทำงานของ setInterval
                clearInterval(interval);

            }
        }, 1000);

        // ใช้ในการทำความสะอาดเมื่อ Component ถูกทำลาย
        return () => {
            clearInterval(interval);
        }

    }, [countdown])

    return (
        <div className='circle' style={{ display: 'flex', justifyContent: 'center', alignItems: 'center' }} >
            <h1 className='text-dark' style={{ fontSize: '16px' }} >
                {countdown === 0 ? 'Auction Ended' : formatTime(countdown)}
            </h1>
        </div>
    )
}

export default Circle