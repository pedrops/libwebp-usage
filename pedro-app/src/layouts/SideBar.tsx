import {
    Grid,
    List,
    ListItem,
    ListItemButton,
    ListItemIcon,
    ListItemText,
    Divider
  } from '@mui/material';
import InboxIcon from '@mui/icons-material/Inbox';
import GroupsIcon from '@mui/icons-material/Groups';
import PersonAddIcon from '@mui/icons-material/PersonAdd';
import PersonRemoveIcon from '@mui/icons-material/PersonRemove';
import EditIcon from '@mui/icons-material/Edit';
import CalendarMonthIcon from '@mui/icons-material/CalendarMonth';
import { useNavigate } from 'react-router-dom';

function SideBar() {
    const navigate = useNavigate()
    const operations = [
        {name:'Get employees', icon:<GroupsIcon/>, to:'employees'},
        {name:'Get period', icon:<CalendarMonthIcon/>, to:'period'},
        {name:'Add employee', icon:<PersonAddIcon/>, to:'add'},
        {name:'Delete employee', icon:<PersonRemoveIcon/>, to:'delete'},
        {name:'Edit employee', icon:<EditIcon/>, to:'edit'},
    ]
  return (
    <Grid item md={2} sx={{borderRight:'1px solid #e0e0e0', height:'100vh'}}>
        <nav aria-label="main mailbox folders">
            <List>
                {operations.map((operation) =>
                    <ListItem key={operation.name} disablePadding>
                        <ListItemButton onClick={() => navigate('/admin/'+operation.to)}>
                            <ListItemIcon>
                                {operation.icon}
                            </ListItemIcon>
                        <ListItemText primary={operation.name} />
                        </ListItemButton>
                    </ListItem>
                )}
            </List>
        </nav>
        <Divider />
    </Grid>
  )
}

export default SideBar