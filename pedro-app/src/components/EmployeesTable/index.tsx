import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import Paper from '@mui/material/Paper';
import { Typography } from '@mui/material';
import { Checkbox } from '@mui/material'
import { EmployeeModel } from '../../models/employeeModel';

interface EmployeeTableProps {
  employeeList:EmployeeModel[],
  action?:any
} 

export default function EmployeeTable({employeeList,action}:EmployeeTableProps) {
  
  return (
    <TableContainer component={Paper}>
      <Table sx={{ minWidth: 650 }} aria-label="simple table">
        <TableHead>
          <TableRow>
            {action && <TableCell align="right">Delete</TableCell>}
            <TableCell align="right">id</TableCell>
            <TableCell align="right">first name</TableCell>
            <TableCell align="right">last name</TableCell>
            <TableCell align="right">addres</TableCell>
            <TableCell align="right">email</TableCell>
            <TableCell align="right">phone number</TableCell>
            <TableCell align="right">profile</TableCell>
            <TableCell align="right">isFulltime</TableCell>
            <TableCell align="right">hourRate</TableCell>
            <TableCell align="right">active</TableCell>
            <TableCell align="right">insertedDate</TableCell>
            <TableCell align="right">updatedDate</TableCell>
            </TableRow>
        </TableHead>
        <TableBody>
          {employeeList.map((employee, index) => (
            <TableRow
              key={employee.id}
              sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
            >
              {action &&
              <TableCell align="right">
                <Checkbox onClick={() => action(index)}/>
              </TableCell>}
              <TableCell align="right">{employee.id}</TableCell>
              <TableCell component="th" scope="employee">
                {employee.firstName}
              </TableCell>
              <TableCell align="right">{employee.lastName}</TableCell>
              <TableCell align="right">{employee.addres}</TableCell>
              <TableCell align="right">{employee.email}</TableCell>
              <TableCell align="right">{employee.phoneNumber}</TableCell>
              <TableCell align="right">{employee.profile}</TableCell>
              <TableCell align="right">{employee.isFullTime? 'full time':'no fulltime'}</TableCell>
              <TableCell align="right">{employee.hourRate}</TableCell>
              <TableCell align="right">
                <Typography sx={{color:employee.active? 'green':'red'}}>
                  {employee.active? 'active':'inactive'}
                </Typography>
              </TableCell>
              <TableCell align="right">{employee.insertedDate}</TableCell>
              <TableCell align="right">{employee.updatedDate}</TableCell>
            </TableRow>
          ))}
        </TableBody>
      </Table>
    </TableContainer>
  );
}
