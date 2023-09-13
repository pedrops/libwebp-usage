import { useEffect, useState } from 'react'
import { EmployeeModel } from '../models/employeeModel'
import { WeekPeriodModel } from '../models/weekPeriodModel'

const API = 'https://localhost:7224/api/Employee/'

export default function useGetPeriod ( ) {
    const [ period, setPeriod ] = useState<WeekPeriodModel>()
    function getPeriod({employeeId, weekPeriodId}:{employeeId:number, weekPeriodId:string}){
        fetch(API+'GetEmployeeByEmployeeAndWeekPeriod'+'?weekPeriodId='+weekPeriodId+'&employeeId='+employeeId)
            .then(res => res.json())
            .then(data => setPeriod(data))
        return period
    }
    return {getPeriod}
}