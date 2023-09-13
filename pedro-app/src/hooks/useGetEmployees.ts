import { useEffect, useState } from 'react'
import { EmployeeModel } from '../models/employeeModel'

const API = 'https://localhost:7224/api/Employee'

export default function useGetEmployees () {
    const [ employees, setEmployees ] = useState<EmployeeModel[]>([])
    useEffect(() => {
        fetch(API)
        .then(res => res.json())
        .then(data => setEmployees(data))
    })
    return {employees}
}