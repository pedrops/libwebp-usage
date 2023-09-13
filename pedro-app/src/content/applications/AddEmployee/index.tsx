import SetEmployeeMinData from '../../../components/EmployeeMinDataForm'
import ApplicationHeader from '../../../layouts/ApplicationHeader'

function AddEmployee() {
  return (
    <>
    <ApplicationHeader headerText='Add employee'/>
    <SetEmployeeMinData type='add'/>
    </>
  )
}

export default AddEmployee