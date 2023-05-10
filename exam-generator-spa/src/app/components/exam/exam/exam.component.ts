import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AskedQuestionForClientDto } from 'src/app/models/askedQuestionForClientDto';
import { StudentOperationService } from 'src/app/services/student-operation.service';

@Component({
  selector: 'app-exam',
  templateUrl: './exam.component.html',
  styleUrls: ['./exam.component.css'],
})
export class ExamComponent implements OnInit {

  askedQuestionForClientDto: AskedQuestionForClientDto [] = []; 
  // examResponseModel!: ExamResponseModel
  
  //   = {
  //   data: [],
  //   errors:  []
  // };
  apiUrl: string = 'https://localhost:44319/api/StudentOperations/TakeExam/1';
  constructor(private studentOperationService: StudentOperationService) {}
  ngOnInit(): void {
    this.getExam();
  }

  getExam() {
    this.studentOperationService.getExam().subscribe((response) => {
      this.askedQuestionForClientDto = response.data;
      console.log(this.askedQuestionForClientDto);
    });

    
  }
}
