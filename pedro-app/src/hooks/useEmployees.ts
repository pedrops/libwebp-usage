import { useEffect, useState } from "react";
import { EmployeeModel } from "../models/employeeModel";
import { WeekPeriodModel } from "../models/weekPeriodModel";

const API = "https://localhost:7224/api/"

const employees:EmployeeModel[] = [
    {
      id:0,
      address:'sí',
      firstName:'Andy1',
      lastName:'Vargas',
      addres:'Av. pardo',
      email:'@email.com',
      phoneNumber:'987654321',
      profile:'admin xd',
      isFullTime:true,
      hourRate:24,
      active:true,
      insertedDate:'11/09/2001',
      updatedDate:'08/09/2023'},
  ];

function useEmployees() {
    function deleteEmployees ({idsToDelete}:{idsToDelete:number[]}) {
      idsToDelete.forEach((id) =>{
        console.log('deleted: ',id)
      })
    }
    return {deleteEmployees}
  }
  
  export default useEmployees