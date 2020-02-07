
import { environment } from "src/environments/environment";
import { throwError } from "rxjs";

export class ServiceBase {
    protected UrlServiceV1: string = environment.servico;


    protected extractData(response: any) {
        return response.data || {};
    }

    errorHandl(error) {
        let errorMessage = '';
        if(error.error instanceof ErrorEvent) {
          // Get client-side error
          errorMessage = error.error.message;
        } else {
          // Get server-side error
          errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
        }
        console.log(errorMessage);
        return throwError(errorMessage);
     }
}