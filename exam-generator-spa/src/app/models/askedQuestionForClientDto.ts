import { AskedQuestionOptionForClientDto } from "./askedQuestionOptionForClientDto";

export interface AskedQuestionForClientDto{
    questionContent: string,
    questionOptions: AskedQuestionOptionForClientDto[]
}