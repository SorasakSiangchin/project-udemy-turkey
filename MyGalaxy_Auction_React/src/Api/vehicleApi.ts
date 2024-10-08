/* eslint-disable @typescript-eslint/no-explicit-any */
import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";

// createApi => ช่วยจัดการการเรียก API และการจัดการสถานะ (state) ที่เกี่ยวข้องกับการเรียก API นั้นๆ
const vehicleApi = createApi({
  // ระบุชื่อ
  reducerPath: "vehicleApi",
  // กำหนด base api
  baseQuery: fetchBaseQuery({
    baseUrl: "http://localhost:5145/api/Vehicle/",
  }),
  // ระบุ endpoints
  endpoints: (builder) => ({
    getVehicles: builder.query({
      query: () => ({
        url: "GetVehicles",
      }),
    }),
    getVehicleById: builder.query({
      query: (id: any) => ({
        url: `${id}`,
      }),
    }),
  }),
});

// มันจะ generate hooks ให้เราใช้งาน (กำหนดชื่อให้ด้วย)
export const { useGetVehiclesQuery, useGetVehicleByIdQuery } = vehicleApi;
export default vehicleApi;
