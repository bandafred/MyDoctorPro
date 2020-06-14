import {InfusionRateResponse, InfusionRateClient} from "../../../../apiClient/apiClient";
import {IResult, IErrors} from '../../../../common/Interfaces';
import {getAuthClient} from "../../../../apiClient/getAuthClient";


export async function InfusionRateResult(bodyMass: number, amountDrug: number, volumeSolution: number, dose: number) {
    let res: IResult<InfusionRateResponse> = {
        result: undefined,
        error: undefined
    };

    try {
        let client = new InfusionRateClient(getAuthClient());
        res.result = await client.calculateInfusionRate(bodyMass, amountDrug, volumeSolution, dose);

        return res;

    } catch (error) {
        res.error = <IErrors>JSON.parse(error.response);
        return res;
    }
}