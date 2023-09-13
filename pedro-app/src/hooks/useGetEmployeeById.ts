import { useEffect, useState } from 'react'
import { EmployeeModel } from '../models/employeeModel'

const API = 'https://localhost:7224/api/Employee/GetEmployeeById?Id='

export default function useGetEmployeeById () {
    async function getEmployeeById({id}:{id:number}) {
        const res = await fetch(API+id)
        const data = await res.json()
        return data
    }
    return {getEmployeeById}
}