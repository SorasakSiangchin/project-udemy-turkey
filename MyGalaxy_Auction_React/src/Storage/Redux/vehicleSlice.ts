import { createSlice } from "@reduxjs/toolkit";

const initialState = {
  vehicles: [],
};

const vehicleSlice = createSlice({
  name: "vehicle",
  initialState,
  reducers: {
    getVehicles: (state, action) => {
      state.vehicles = action.payload;
    },
  },
});

export const { getVehicles } = vehicleSlice.actions;
export const vehicleReducer = vehicleSlice.reducer;
