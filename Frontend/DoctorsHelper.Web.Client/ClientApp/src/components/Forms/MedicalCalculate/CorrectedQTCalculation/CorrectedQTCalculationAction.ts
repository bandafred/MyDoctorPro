import {
    CorrectedQTCalculationResponse,
    CorrectedQTCalculationClient
} from "../../../../apiClient/apiClient";
import {IResult, IErrors} from '../../../../common/Interfaces';
import {getAuthClient} from "../../../../apiClient/getAuthClient";


export async function CorrectedQTCalculationResult(heartRate: number, intervalQT: number) {
    let res: IResult<CorrectedQTCalculationResponse> = {
        result: undefined,
        error: undefined
    };

    try {
        let client = new CorrectedQTCalculationClient(getAuthClient());
        res.result = await client.calculateCorrectedQTCalculation(heartRate, intervalQT);

        return res;

    } catch (error) {
        res.error = <IErrors>JSON.parse(error.response);
        return res;
    }
}