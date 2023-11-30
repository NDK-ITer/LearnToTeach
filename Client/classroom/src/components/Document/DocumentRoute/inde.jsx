
import React, { useEffect, useState } from 'react';
import { Redirect, Route, Switch, useRouteMatch } from 'react-router-dom';
import Exercises from 'components/Exercises/Exercises';
import CreateExercise from 'components/CreateExercise';
import ExerciseDetail from 'components/Exercises/ExerciseDetail/ExerciseDetail';
import classApi from 'api/classApi';
import SubmitExercise from 'components/Exercises/SubmitExercise/SubmitExercise';
import Role from 'constants/role';
import { useLocalContext } from 'context';
import { ProtectedRouteUserHost, ProtectedRouteUserMember } from 'routes/Routes';
import Document from 'components/Document/Document';
import DocumentDetail from 'components/Document/DocumentDetail/DocumentDetail';
function DocumentRoute({ classData }) {
    const { user } = useLocalContext();
    const match = useRouteMatch();
    const [isUserHost, setisUserHost] = useState(false);
    const [userHost, setuserHost] = useState([]);
    const [userMember, setisUserMember] = useState([]);
    const [document, setdocument] = useState([]);
    useEffect(() => {
        const fetchData = async () => {
            const params = new URLSearchParams([['idClassroom', classData.idClassroom]]);
            const result = await classApi.getClassById(params);
            setdocument(result.listDocument);
            setuserHost(result.listMembers.find(x => x.role == Role.HOST));
            setisUserHost(result.listMembers.filter(x => x.role == Role.HOST && user.id == x.idMember).length > 0 ? true : false);
            setisUserMember(result.listMembers.filter(x => x.role == Role.MEMBER && user.id == x.idMember).length > 0 ? true : false);
        };
        fetchData();
    }, []);
    console.log(document)
    return (
        <>
            <Switch>
                <Route exact path={match.url}>
                    <Document classData={classData} />
                </Route>
                {document.map((item, index) => (
                    <Route key={index} exact path={`${match.url}/${item.nameFile}`}>
                        <DocumentDetail document={item} />
                    </Route>

                ))}


            </Switch>

        </>

    );
}

export default DocumentRoute;
