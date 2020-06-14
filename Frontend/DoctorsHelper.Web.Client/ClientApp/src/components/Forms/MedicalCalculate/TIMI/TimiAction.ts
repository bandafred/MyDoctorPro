import {TimiScaleResponse, TimiScaleClient} from "../../../../apiClient/apiClient";
import {IResult, IErrors} from '../../../../common/Interfaces';
import {getAuthClient} from "../../../../apiClient/getAuthClient";

export async function TimiResult(oldAge: boolean, threeRisk: boolean, stenos: boolean, liftSt: boolean, stenocardia: boolean, aspirin: boolean, necroze: boolean) {
    let res: IResult<TimiScaleResponse> = {
        result: undefined,
        error: undefined
    };

    try {
        let client = new TimiScaleClient(getAuthClient());
        res.result = await client.calculateTimiScale(oldAge, threeRisk, stenos, liftSt, stenocardia, aspirin, necroze);

        return res;

    } catch (error) {
        res.error = <IErrors>JSON.parse(error.response);
        return res;
    }
}