import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ListResponseModel } from '../models/listResponseModel';
import { AskedQuestionForClientDto } from '../models/askedQuestionForClientDto';

@Injectable({
  providedIn: 'root'
})
export class StudentOperationService {

  apiUrl: string = 'https://localhost:44319/api/StudentOperations/TakeExam/1';
  constructor(private httpClient: HttpClient) { }


  getExam(): Observable<ListResponseModel<AskedQuestionForClientDto>> {
    return this.httpClient.get<ListResponseModel<AskedQuestionForClientDto>>(this.apiUrl);
  }
}
