import { configureStore } from "@reduxjs/toolkit";
import { vehicleReducer } from "./Redux/vehicleSlice";
import vehicleApi from "../Api/vehicleApi";
import { accountApi } from "../Api/accountApi";
import { authenticationReducer } from "./Redux/authenticationSlice";
import bidApi from "../Api/bidApi";
import paymentHistoryApi from "../Api/paymentHistoryApi";

const store = configureStore({
  reducer: {
    vehicleReducer,
    authenticationReducer,
    // [] มีความสำคัญเมื่อ key นั้นเป็นตัวแปรหรือ expression ที่ต้องการการประเมินผล (evaluation) ก่อนที่จะใช้เป็น key จริงๆ
    // ในกรณีนี้, JavaScript จะพยายามใช้ accountApi.reducerPath และ vehicleApi.reducerPath เป็น string ตรงๆ ซึ่งจะทำให้เกิดข้อผิดพลาดทางไวยากรณ์ (syntax error).
    [vehicleApi.reducerPath]: vehicleApi.reducer,
    [accountApi.reducerPath]: accountApi.reducer,
    [bidApi.reducerPath]: bidApi.reducer,
    [paymentHistoryApi.reducerPath]: paymentHistoryApi.reducer,
  },
  middleware: (getDefaultMiddleware) =>
    getDefaultMiddleware().concat(vehicleApi.middleware, accountApi.middleware, bidApi.middleware, paymentHistoryApi.middleware),
});

export type RootState = ReturnType<typeof store.getState>;
export default store;
