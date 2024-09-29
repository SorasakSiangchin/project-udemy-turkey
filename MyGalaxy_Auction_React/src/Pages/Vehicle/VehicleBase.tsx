import React, { useEffect, useState } from 'react'
import { useGetVehiclesQuery } from '../../Api/vehicleApi';
import { VehicleModel } from '../../interfaces/vehicleModel';
import VehicleList from './VehicleList';
import Banner from './Banner';

const VehicleBase = () => {
    const { data, isLoading } = useGetVehiclesQuery(null);
    const [vehicles, setVehicles] = useState<VehicleModel[]>([])

    useEffect(() => {
        if (data)
            setVehicles(data.result)
    }, [data])

    return (
        <div className="container">
            <Banner />
            <div className="row">
                <VehicleList vehicles={vehicles} />
            </div>
        </div>
    )
}

export default VehicleBase