import {BodyMassIndexResponse, BodyMassIndexClient} from "../../../../apiClient/apiClient";
import {IResult, IErrors} from '../../../../common/Interfaces';
import {getAuthClient} from "../../../../apiClient/getAuthClient";

export async function BodyMassIndexResult(height: number, weight: number) {
    let res: IResult<BodyMassIndexResponse> = {
        result: undefined,
        error: undefined,
    };

    try {
        let client = new BodyMassIndexClient(getAuthClient());
        res.result = await client.calculateBodyMassIndex(height, weight);

        return res;

    } catch (error) {
        res.error = <IErrors>JSON.parse(error.response);
        return res;
    }
}