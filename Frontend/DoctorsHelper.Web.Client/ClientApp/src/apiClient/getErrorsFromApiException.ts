import {ApiException} from "./apiClient";
import {IErrors} from "../common/Interfaces";

//TODO: Нужна более сложная модель ответа, чтобы обрабатывать все вариации ошибки, включая недоступный сервер 
export const getErrorsFromApiException = (error: any) => {
    if(error.isApiException){
        let apiException = error as ApiException;
        if(apiException.response)
        {
            let responseParsed = JSON.parse(apiException.response);
            if(responseParsed.errors)
                return (responseParsed as IErrors).errors;
        }
        if(apiException.status === 401)
            return ["Неавторизованный доступ"];
        
    }    
    return ["Ошибка сервера"];
}


