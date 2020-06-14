import {
    GeneralMedicalContraindicationResponse,
    GeneralMedicalContraindicationClient
} from "../../../../../apiClient/apiClient";
import {IResult, IErrors} from '../../../../../common/Interfaces';
import {getAuthClient} from "../../../../../apiClient/getAuthClient";

export async function GetGeneralMedicalContraindicationRecords(searchText: string | null | undefined) {
    let res: IResult<GeneralMedicalContraindicationResponse> = {
        result: undefined,
        error: undefined,
    };

    try {
        let client = new GeneralMedicalContraindicationClient(getAuthClient());
        res.result = await client.getRecords(searchText);

        return res;

    } catch (error) {
        res.error = <IErrors>JSON.parse(error.response);
        return res;
    }

}