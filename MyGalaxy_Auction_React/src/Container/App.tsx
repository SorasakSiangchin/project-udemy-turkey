import "./App.css";
import VehicleBase from "../Pages/Vehicle/VehicleBase";
import { Header } from "../Layout";
import { Route, Routes } from "react-router-dom";
import VehicleDetail from "../Pages/Vehicle/VehicleDetail";
import Register from "../Pages/Account/Register";
import Login from "../Pages/Account/Login";
import { useDispatch } from "react-redux";
import { useEffect } from "react";
import { jwtDecode } from "jwt-decode";
import userModel from "../interfaces/userModel";
import { setLoggedInUser } from "../Storage/Redux/authenticationSlice";
import BidCheckout from "../Pages/Bid/BidCheckout";
import Payment from "../Pages/Payment/Payment";

function App() {
  const Dispatch = useDispatch();
  useEffect(() => {
    const token = localStorage.getItem("token");
    if (token) {
      const { nameid, email, role, fullName }: userModel = jwtDecode(token);
      Dispatch(setLoggedInUser({
        nameid, email, role, fullName
      }))
    }
  }, []);

  return (
    <div>
      <Header />
      <div className="pb-5">
        <Routes>
          <Route path="/" element={<VehicleBase />} ></Route>
          <Route path="/Vehicle/VehicleId/:vehicleId" element={<VehicleDetail />} ></Route>
          <Route path="/Register" element={<Register />} />
          <Route path="/Login" element={<Login />} />
          <Route path="/Vehicle/BidCheckout/:vehicleId" element={<BidCheckout />} />
          <Route path="/Payment" element={<Payment />} />
        </Routes>
      </div>
    </div>
  );
}

export default App;
