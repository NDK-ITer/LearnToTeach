import React from 'react';
import "./style.css";
import { Avatar } from '@material-ui/core';
import EditNoteOutlinedIcon from '@mui/icons-material/EditNoteOutlined';
import Button from '@mui/material/Button';
import TextField from '@mui/material/TextField';
import { DemoContainer } from '@mui/x-date-pickers/internals/demo';
import { AdapterDayjs } from '@mui/x-date-pickers/AdapterDayjs';
import { LocalizationProvider } from '@mui/x-date-pickers/LocalizationProvider';
import { DateTimePicker } from '@mui/x-date-pickers/DateTimePicker';
import InputLabel from '@mui/material/InputLabel';
import MenuItem from '@mui/material/MenuItem';
import FormControl from '@mui/material/FormControl';
import Select from '@mui/material/Select';
import Checkbox from '@mui/material/Checkbox';
import FormControlLabel from '@mui/material/FormControlLabel';

const CreateExercise = () => {
  return (
    <div>
        <div className='header'>
            <Avatar style={{m: 1, backgroundColor: 'black',}}>
                <EditNoteOutlinedIcon/>
            </Avatar>
            <h1 className='header_text'> Tạo bài tập </h1>
            <div className='group_btn'>
              <Button
                onclick={'#'}
                type="submit"
                variant="outlined"
                sx={{ margin: 1}}
              >
                Hủy
              </Button>
              <Button
                onclick={'#'}
                type="submit"
                variant="outlined"
                sx={{ margin: 1}}
              >
                Lưu nháp
              </Button>
              <Button
                onclick={'#'}
                type="submit"
                variant="contained"
                sx={{ margin: 1}}
              >
                Giao bài
              </Button>
            </div>
            
        </div>
      <div className='main_content'>
        <div className='title'>
          <TextField
            fullWidth
            id="title"
            label="Tiêu đề*"
            name="title"
            variant='filled'
            //size="small"
            autoComplete="off"
          />
        </div>
        <div className='content'>
          <TextField
            fullWidth
            id="content"
            label="Nội dung (không bắt buộc)"
            name="content"
            multiline
            rows={5}
            variant="filled"
            autoComplete="off"
          />
        </div>
        <div className='attachment'>
          <p className='text'>Đính kèm tệp: </p>
          <div>
            <Button 
              size='medium'
              sx={{borderRadius: 10}}
              variant="contained"
              component="label"
            >
              Tải lên
              <input
                type="file"
                hidden
              />
            </Button>
          </div>     
        </div>
        <div className='time'>
          <p className='text'>Hạn nộp:</p>
          <div className='picktime'>
            <LocalizationProvider dateAdapter={AdapterDayjs}>
              <DemoContainer components={['DateTimePicker']} >
                <DateTimePicker label="Ngày hết hạn" />
              </DemoContainer>
            </LocalizationProvider>
            <FormControlLabel control={<Checkbox defaultChecked />} label="Đóng nộp bài sau khi hết hạn" />
          </div>         
        </div>
        <div className='max_grade'>
          <p className='text'>Điểm tối đa:</p>
          <div className='cbb_grade'>
          <FormControl sx={{ minWidth: 150 }} size="small">
            <InputLabel id="demo-select-small-label">Điểm</InputLabel>
            <Select
              labelId="demo-select-small-label"
              id="demo-select-small"
              //value={grade}
              label="Điểm"
              //onChange={handleChange}
            >
              {/* <MenuItem value="">
                <em>Điểm</em>
              </MenuItem> */}
              <MenuItem value={0}>Không</MenuItem>
              <MenuItem value={1}>1</MenuItem>
              <MenuItem value={2}>2</MenuItem>
              <MenuItem value={3}>3</MenuItem>
              <MenuItem value={4}>4</MenuItem>
              <MenuItem value={5}>5</MenuItem>
              <MenuItem value={6}>6</MenuItem>
              <MenuItem value={7}>7</MenuItem>
              <MenuItem value={8}>8</MenuItem>
              <MenuItem value={9}>9</MenuItem>
              <MenuItem value={10}>10</MenuItem>
            </Select>
          </FormControl>
          </div>
        </div>
      </div>
    </div>
  )
}

export default CreateExercise
