import { Link } from "react-router-dom";
import { VehicleModel } from "../../interfaces/vehicleModel";
import Circle from "./Circle";
import "./Styles/VehicleList.css";


const VehicleList = ({ vehicles }: { vehicles: VehicleModel[] }) => {

  return (
    <>
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
                <Link to={`/Vehicle/VehicleId/${vehicle.vehicleId}`} >
                  <button className="btn btn-danger">Detail</button>
                </Link>
              </div>
              <Circle vehicle={vehicle} />
            </div>
          </div>
        })
      }
    </>
  );
};

export default VehicleList;
