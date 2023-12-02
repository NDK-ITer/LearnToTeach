
import React, { useEffect, useState } from 'react';
import classApi from 'api/classApi';
import Role from 'constants/role';
import { useLocalContext } from 'context';
import Grade from 'components/Grade/Grade';
import { Route, Switch, useRouteMatch } from 'react-router-dom';
import GradeDetail from '../GradeDetail/GradeDetail';
import GardeUserAnswer from '../GradeDetail/GardeUserAnswer/GardeUserAnswer';
function GradeRoute({ classData }) {
    const { user } = useLocalContext();
    const match = useRouteMatch();
    const [exercises, setexercises] = useState([])
    const [isUserHost, setisUserHost] = useState(false);
    const [userHost, setuserHost] = useState([]);
    const [classdata, setclassdata] = useState([]);
    const [isUserMember, setisUserMember] = useState(false);
    const [userlist, setuserlist] = useState([])
    useEffect(() => {
        const fetchData = async () => {
            const params = new URLSearchParams([['idClassroom', classData.idClassroom]]);
            const result = await classApi.getClassById(params);
            setclassdata(result)
            setuserlist(result.listMembers)
            setexercises(result.listExercises);
            setuserHost(result.listMembers.find(x => x.role == Role.HOST));
            setisUserHost(result.listMembers.filter(x => x.role == Role.HOST && user.id == x.idMember).length > 0 ? true : false);
            setisUserMember(result.listMembers.filter(x => x.role == Role.MEMBER && user.id == x.idMember).length > 0 ? true : false);
        };
        fetchData();
    }, []);
    console.log(userlist)
    return (
        <>
            <Switch>
                <Route exact path={`${match.url}`}>
                    <Grade classData={classData} />
                </Route>
                {exercises.map((item, index) => (
                    <Route key={index} exact path={`${match.url}/${item.idExercise}`}>
                        <GradeDetail classData={classdata} exercise={item} userHost={userHost} />
                    </Route>
                ))}
            </Switch>
        </>

    );
}

export default GradeRoute;
