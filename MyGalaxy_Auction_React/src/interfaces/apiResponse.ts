export interface apiResponse {
    data?: {
        statusCode?: number
        isSuccess?: boolean
        errorMessages?: string[]
        result: {
            [key: string]: string
        }
    };
    // eslint-disable-next-line @typescript-eslint/no-explicit-any
    error?: any;


}
