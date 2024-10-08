import { createSlice } from "@reduxjs/toolkit";

const initialState = {
  vehicles: [],
  vehicleId: ""
};

const vehicleSlice = createSlice({
  name: "vehicle",
  initialState,
  reducers: {
    getVehicles: (state, action) => {
      state.vehicles = action.payload;
    },
    getVehicle: (state, action) => {
      state.vehicleId = action.payload
    },
  },
});

export const { getVehicles, getVehicle } = vehicleSlice.actions;
export const vehicleReducer = vehicleSlice.reducer;
