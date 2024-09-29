import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";

export const bidApi = createApi({
    reducerPath: "bidApi",
    baseQuery: fetchBaseQuery({
        baseUrl: "https://localhost:7015/api/Bid/"
    }),
    endpoints: (builder) => ({
        // query => GET
        getBidByVehicleId: builder.query({
            query: (vehicleId) => ({
                method: "GET",
                url: `GetBidsByVehicle/${vehicleId}`,

            })
        })
    }),
})

export const { useGetBidByVehicleIdQuery } = bidApi;
export default bidApi;