import { createSlice } from "@reduxjs/toolkit";
import userModel from "../../interfaces/userModel";

export const initialState: userModel = {
    nameid: "",
    fullName: "",
    email: "",
    role: ""
}


export const authenticationSlice = createSlice({
    name: "authentication",
    initialState,
    reducers: {
        setLoggedInUser: (state, action) => {
            state.email = action.payload.email;
            state.fullName = action.payload.fullName;
            state.nameid = action.payload.nameid;
            state.role = action.payload.role
        }
    }
})

export const { setLoggedInUser } = authenticationSlice.actions
export const authenticationReducer = authenticationSlice.reducer;