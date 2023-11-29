import React, {useState} from 'react';
import './style.css';
import { NavigationBar} from "..";
import 'bootstrap/dist/css/bootstrap.css'
import { Viewer } from '@react-pdf-viewer/core';
import { defaultLayoutPlugin } from '@react-pdf-viewer/default-layout';
import { Worker } from '@react-pdf-viewer/core';


const Document = () => {

    const defaultLayoutPluginInstance = defaultLayoutPlugin();

    const [pdfFile, setPdfFile] = useState(null);
    const [pdfFileError, setPdfFileError] = useState('');

    const [viewPdf, setViewPdf] = useState(null);

    const fileType=['application/pdf'];
    const handlePdfFileChange=(e)=>{
        let selectedFile = e.target.file[0];
        if(selectedFile) {
            if(selectedFile && fileType.includes(selectedFile.type)){
                let reader = new FileReader();
                reader.readAsDataURL(selectedFile);
                reader.onloadend = (e) =>{
                    setPdfFile(e.target.result);
                    setPdfFileError('');
                }
            }
            else{
                setPdfFile(null);
                setPdfFileError('Chỉ chọn file định dạng PDF');
            }
        }
        else{
            console.log('Chọn file PDF muốn tải lên');
        }
    }

    const handlePdfFileSubmit=(e)=>{
        e.preventDefault();
        if(pdfFile!==null){
          setViewPdf(pdfFile);
        }
        else{
          setViewPdf(null);
        }
      }

  return (
    <div>
        <NavigationBar/>
        <br></br>
        <div className='container'>
            <form className='form-group' onSubmit={handlePdfFileSubmit}>
                <input type="file" className='form-control' required onChange={handlePdfFileChange}>               
                </input>
                {pdfFileError&&<div className='error-msg'>{pdfFileError}</div>}
                <br></br>
                <button type="submit" className='btn btn-success btn-lg'>
                    Tải lên
                </button>
            </form>
            <br></br>
            <h4>Xem file PDF</h4>
            <div className='pdf-container'>
                {viewPdf&&<><Worker workerUrl="https://unpkg.com/pdfjs-dist@2.6.347/build/pdf.worker.min.js">
                <Viewer fileUrl={viewPdf}
                    plugins={[defaultLayoutPluginInstance]} />
                </Worker></>}
                {!viewPdf&&<>Không có file PDF nào</>}
            </div>
        </div>
    </div>
    
  )
}

export default Document
