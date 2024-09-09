import { configureStore } from "@reduxjs/toolkit";
import { vehicleReducer } from "./Redux/vehicleSlice";
import vehicleApi from "../Api/vehicleApi";

const store = configureStore({
  reducer: {
    vehicleReducer,
    [vehicleApi.reducerPath]: vehicleApi.reducer,
  },
  middleware: (getDefaultMiddleware) =>
    // middleware: (getDefaultMiddleware) =>
    getDefaultMiddleware().concat(vehicleApi.middleware),
});

export type RootState = ReturnType<typeof store.getState>;
export default store;