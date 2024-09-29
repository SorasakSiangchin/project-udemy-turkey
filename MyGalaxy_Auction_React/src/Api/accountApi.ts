import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";

// ข้อดีของการใช้งาน createApi จาก @reduxjs/toolkit
// - ลดโค้ดที่ต้องเขียน
// - การจัดการแคชอัตโนมัติ
//RTK Query จะจัดการแคชของข้อมูลที่ได้รับจาก API อัตโนมัติ, ทำให้ไม่ต้องเรียก API ซ้ำๆ เมื่อข้อมูลยังไม่หมดอายุ.
// - การจัดการสถานะการโหลดและข้อผิดพลาด
// RTK Query จะจัดการสถานะการโหลดและข้อผิดพลาดให้โดยอัตโนมัติ, ทำให้สามารถแสดงสถานะการโหลดหรือข้อผิดพลาดได้ง่ายขึ้น.
// - การรวมกับ Redux DevTools
// RTK Query สามารถรวมกับ Redux DevTools ได้อย่างง่ายดาย, ทำให้สามารถตรวจสอบสถานะของการเรียก API และการจัดการแคชได้.
// - การจัดการการเรียก API ที่ซับซ้อน
// RTK Query รองรับการจัดการการเรียก API ที่ซับซ้อน เช่น การเรียก API หลายๆ ครั้งพร้อมกัน, การจัดการการเรียก API ที่ต้องการการยืนยันตัวตน (authentication), และอื่นๆ.
// - การรวมกับ TypeScript
export const accountApi = createApi({
    reducerPath: 'accountApi',
    baseQuery: fetchBaseQuery({
        baseUrl: 'https://localhost:7015/api/User/'
    }),
    endpoints: (builder) => ({
        signUp: builder.mutation({
            query: (userData) => ({
                url: 'Register',
                method: 'POST',
                headers: {
                    "Content-type": "application/json"
                },
                body: userData
            }),
        }),
        signIn: builder.mutation({
            query: (userData) => ({
                url: "Login",
                method: "POST",
                headers: {
                    "Content-type": "application/json"
                },
                body: userData
            })
        })
    })
})

export const { useSignUpMutation, useSignInMutation } = accountApi;