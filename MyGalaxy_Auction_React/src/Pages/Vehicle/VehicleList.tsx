import { useEffect, useState } from "react";
import { useGetVehiclesQuery } from "../../Api/vehicleApi";
import { VehicleModel } from "../../interfaces/vehicleModel";
import "./Styles/VehicleList.css";
import Circle from "./Circle";

const VehicleList = () => {
  const { data, isLoading } = useGetVehiclesQuery(null);
  const [vehicles, setVehicles] = useState<VehicleModel[]>([])

  useEffect(() => {
    if (data)
      setVehicles(data.result)
  }, [data])

  return (
    <div className="container">
      <div className="row">
        {
          vehicles.map((vehicle, index) => {
            return <div className="col">
              <div key={index} className="auction-card text-center">
                <div className="card-image text-center">
                  <img src={vehicle.image} alt="" />
                </div>
                <div className="card-details text-center">
                  <h2>{vehicle.brandAndModel}</h2>
                  <p><strong>Year:</strong>{vehicle.manufacturingYear}</p>
                  <p><strong>Color:</strong>{vehicle.manufacturingYear}</p>
                  <p><strong>Current Bid:</strong> ${vehicle.price}</p>
                  <p><strong>End Time:</strong>{vehicle.endTime}</p>
                </div>
                <div>
                  <button className="btn btn-danger">Detail</button>
                </div>
                <Circle vehicle={vehicle} />
              </div>
            </div>
          })
        }
      </div>
    </div>
  );

};

export default VehicleList;
