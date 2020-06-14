import {
    AntihypertensiveTherapyResponse,
    AntihypertensiveTherapyClient
} from "../../../../apiClient/apiClient";
import {IResult, IErrors} from '../../../../common/Interfaces';
import {getAuthClient} from "../../../../apiClient/getAuthClient";

export async function AntihypertensiveTherapyResult(age: number, isMen: boolean, systolicBloodPressure: number, diastolicBloodPressure: number, pulse: number, diseases: number[]) {
    let res: IResult<AntihypertensiveTherapyResponse> = {
        result: undefined,
        error: undefined,
    };

    try {
        let client = new AntihypertensiveTherapyClient(getAuthClient());
        res.result = await client.calculateAntihypertensiveTherapy(age, isMen, systolicBloodPressure, diastolicBloodPressure, pulse, diseases);

        return res;

    } catch (error) {
        res.error = <IErrors>JSON.parse(error.response);
        return res;
    }
}