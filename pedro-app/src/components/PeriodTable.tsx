import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import Paper from '@mui/material/Paper';
import { WeekPeriodModel } from '../models/weekPeriodModel';

export default function PeriodTable({period}:{period:WeekPeriodModel}) {
    const periodData = [
        {title:'firstName', content:period.firstName},
        {title:'lastName', content:period.lastName},
        {title:'address', content:period.address},
        {title:'email', content:period.email},
        {title:'phoneNumber', content:period.phoneNumber},
        {title:'profile', content:period.profile},
        {title:'isFullTime', content:period.isFullTime},
        {title:'hourRate', content:period.hourRate},
        {title:'active', content:period.active},
        {title:'insertedDate', content:period.insertedDate},
        {title:'updatedDate', content:period.updatedDate},
        {title:'workedHours', content:period.workedHours},
        {title:'bonus', content:period.bonus},
        {title:'weekPayment', content:period.weekPayment},
        {title:'weekTotalPayment', content:period.weekTotalPayment},
    ]
  return (
    <TableContainer component={Paper}>
      <Table sx={{ minWidth: 650 }} aria-label="simple table">
        <TableHead>
          <TableRow>
            {periodData.map((data, index) =>
                  <TableCell align="right" key={index}>{data.title}</TableCell>
            )}
          </TableRow>
        </TableHead>
        <TableBody>
            <TableRow
                sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
                >
                {periodData.map((data, index) =>
                    <TableCell align="right">
                        {data.content}
                    </TableCell>
                )}
            </TableRow>
        </TableBody>
      </Table>
    </TableContainer>
  );
}
