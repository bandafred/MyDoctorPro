import {
    PotassiumDeficiencyResponse,
    PotassiumDeficiencyClient
} from "../../../../apiClient/apiClient";
import {IResult, IErrors} from '../../../../common/Interfaces';
import {getAuthClient} from "../../../../apiClient/getAuthClient";

export async function PotassiumDeficiencyResult(bloodKaliumLevel: number, bodyMass: number) {
    let res: IResult<PotassiumDeficiencyResponse> = {
        result: undefined,
        error: undefined
    };

    try {
        let client = new PotassiumDeficiencyClient(getAuthClient());
        res.result = await client.calculatePotassiumDeficiency(bloodKaliumLevel, bodyMass);

        return res;

    } catch (error) {
        res.error = <IErrors>JSON.parse(error.response);
        return res;
    }
}