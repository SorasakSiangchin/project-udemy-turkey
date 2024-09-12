/* eslint-disable @typescript-eslint/no-explicit-any */

export interface VehicleModel {
    vehicleId: number
    brandAndModel: string
    manufacturingYear: number
    color: string
    engineCapacity: number
    price: number
    millage: number
    plateNumber: string
    auctionPrice: number
    additionalInformation: string
    startTime: string
    endTime: string
    isActive: boolean
    image: string
    sellerId: string
    bids: any
}
