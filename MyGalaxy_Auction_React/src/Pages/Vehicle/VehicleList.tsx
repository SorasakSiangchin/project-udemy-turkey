import { useState } from "react";
import { useGetVehiclesQuery } from "../../Api/vehicleApi";

const VehicleList = () => {
  const { data, isLoading } = useGetVehiclesQuery(null);
  const [write, setWrite] = useState("data is loading");

  const handleCLickForVehicle = () => {
    console.log(data);
    setWrite("data is loading console");
  };

  return (
    <div>
      <button className="btn btn-warning" onClick={handleCLickForVehicle}>
        Get Vehicle Data
      </button>
      <h1>{write}</h1>
    </div>
  );
};

export default VehicleList;
