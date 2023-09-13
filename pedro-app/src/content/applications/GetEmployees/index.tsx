import EmployeeTable from '../../../components/EmployeesTable';
import useEmployees from '../../../hooks/useEmployees';
import useGetEmployees from '../../../hooks/useGetEmployees';
import ApplicationHeader from '../../../layouts/ApplicationHeader';

export default function BasicTable() {
  const {employees} = useGetEmployees()
  return (
    <>
        <ApplicationHeader headerText='Employees:'/>
        <EmployeeTable employeeList={employees}/>
    </>
  );
}
