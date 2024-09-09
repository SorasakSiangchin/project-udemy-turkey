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
  }),
});

export const { useGetVehiclesQuery } = vehicleApi;
export default vehicleApi;
