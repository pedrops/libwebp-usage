import { RouteObject } from 'react-router'
import { Suspense, lazy } from "react"
import GeneralLoader from "./commons/GeneralLoader"
import { Navigate } from 'react-router-dom'
import NavBar from './commons/NavBar'
import RequiredLogin from './components/RequiredLogin'

const Loader = (Component:any) => (props:any) => (
    <Suspense fallback={<GeneralLoader/>}>
        <Component {...props}/>
    </Suspense>
)

const GetEmployeesPage = Loader(
    lazy(() => import('./content/applications/GetEmployees'))
)
const Admin = Loader(
    lazy(() => import('./content/pages/Admin'))
)
const LoginPage = Loader(
    lazy(() => import('./content/pages/auth/Login'))
)
const NotFound = Loader(
    lazy(() => import('./commons/404'))
)
const AddEmployee = Loader(
    lazy(() => import('./content/applications/AddEmployee'))
)
const EditEmployee = Loader(
    lazy(() => import('./content/applications/EditEmployee'))
)
const DeleteEmployee = Loader(
    lazy(() => import('./content/applications/DeleteEmployee'))
)
const GetEmployeePeriod = Loader(
    lazy(() => import('./content/applications/GetEmployeePeriod'))
)

const routes:RouteObject[] = [
    {
        path:'/',
        element:<Navigate to={'/admin'} replace/>
    },
    {
        path:'login',
        element:<LoginPage/>
    },
    {
        path:'/admin',
        element:<NavBar/>,
        children:[
            {
                path:'',
                element:<RequiredLogin>
                            <Admin/>
                        </RequiredLogin>,
                children:[
                    {
                        path:'employees',
                        element:<GetEmployeesPage/>
                    },
                    {
                        path:'add',
                        element:<AddEmployee/>
                    },
                    {
                        path:'edit',
                        element:<EditEmployee/>
                    },
                    {
                        path:'delete',
                        element:<DeleteEmployee/>
                    },
                    {
                        path:'period',
                        element:<GetEmployeePeriod/>
                    },
                    {
                        path:'*',
                        element:<NotFound/>
                    }
                ]
            }
        ]
    },
    {
        path:'*',
        element:<NotFound/>
    }
]

export default routes