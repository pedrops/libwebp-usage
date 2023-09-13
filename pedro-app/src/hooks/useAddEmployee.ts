import { useNavigate } from "react-router-dom";
import { EmployeeMinimunData } from "../models/employeeModel";


const API = "https://localhost:7224/api/Employee"

export default function useAddEmployee (){
    console.log('en add hook')
    function addEmployee (employeeData:EmployeeMinimunData) {
        console.log(employeeData)
        fetch(API,{
            headers:{
                'Content-Type':'application/json'
            },
            body:JSON.stringify(employeeData),
            method:'POST'
        })
    }
    function editEmployee (employeeData:EmployeeMinimunData) {
        console.log('en edit', employeeData)
        fetch(API,{
            headers:{
                'Content-Type':'application/json'
            },
            body:JSON.stringify(employeeData),
            method:'PUT'
        })
        alert('done')
    }
    function deleteEmployee (id:number) {
        console.log('en delete', id)
        fetch(API+'?employeeId='+id,{
            method:'DELETE'
        })
        alert('done')
    }

    return {addEmployee, editEmployee, deleteEmployee}
}