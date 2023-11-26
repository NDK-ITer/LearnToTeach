import  React,{useEffect,useState} from 'react';
import { Avatar} from "@material-ui/core";
import Button from '@material-ui/core/Button';
import LibraryBooksOutlinedIcon from '@material-ui/icons/LibraryBooksOutlined';
import classApi from 'api/classApi';
import Role from 'constants/role';
import { useLocalContext } from 'context';
import "./style.css";

const Exercises = ({classData}) => {
  const { user } = useLocalContext();
  const [isUserHost, setisUserHost] = useState(false);
  const [isUserMember, setisUserMember] = useState(false);
  const [exercises, setexercises] = useState([]);
  const userid=JSON.parse(user);

  useEffect(() => {
    const fetchData = async () => {
      const params = new URLSearchParams([['idClassroom', classData.idClassroom]]);
      const result = await classApi.getClassById(params);


     // settuserHost(result.listMembers.filter(x => x.role == Role.HOST ));
     // setuserMember(result.listMembers.filter(x => x.role == Role.MEMBER));
      
    };
    fetchData();
  }, []);

  return (
    <div>
      <Button
        type="submit"
        variant="contained"
        className='btn_create'
        style={{marginLeft:250, borderRadius: 20,backgroundColor:"rgb(25, 118, 210)",color:"#fff"}}
      >
       <a >
        + Tạo bài tập
        </a> 
      </Button>
      <div className='status'>
        <h1 style={{paddingTop:12}}>Đã giao</h1>
      </div>     
      <ul className='list_tasks'>
        <li className='task'>
          <Avatar style={{margin:1 ,backgroundColor: 'rgb(0, 159, 212)'}}>
                <LibraryBooksOutlinedIcon />
          </Avatar>
          <div className='task_name'> Tên bài tập </div>
          <div className='task_deadline'> Thời hạn </div>
        </li>
      </ul>     
      <div className='status'>
        <h1 style={{paddingTop:12}}>Đã hoàn thành</h1>
      </div>     
      <ul className='list_tasks'>
        <li className='task'>
          <Avatar style={{m:1 ,backgroundColor: 'rgb(4, 214, 46)'}}>
                <LibraryBooksOutlinedIcon />
          </Avatar>
          <div className='task_name'> Tên bài tập </div>
          <div className='task_deadline'> Đã nộp </div>
        </li>
      </ul>     
      <div className='status'>
        <h1 style={{paddingTop:12}}>Chưa hoàn thành</h1>
      </div>     
      <ul className='list_tasks'>
        <li className='task'>
          <Avatar style={{m:1 ,backgroundColor: 'rgb(233, 0, 0)'}}>
                <LibraryBooksOutlinedIcon />
          </Avatar>
          <div className='task_name'> Tên bài tập </div>
          <div className='task_deadline'> Thời hạn </div>
        </li>
      </ul>     
    </div>
  )
}

export default Exercises;
