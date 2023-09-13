export type EmployeeModel = {
    id:number,
    address:string,
    firstName:string,
    lastName:string,
    addres:string,
    email:string,
    phoneNumber:string, 
    profile:string,
    isFullTime:boolean,
    hourRate:number,
    active:boolean,
    insertedDate:string,
    updatedDate:string,
}

export type EmployeeMinimunData = {
    id:number | undefined,
    firstName: string,
    lastName: string,
    address: string,
    email: string,
    phoneNumber: string,
    profile: string,
    hourRate: number,
    isFullTime:boolean,
    active:boolean
}