import {CHA2DS2VAScResponse, CHA2DS2VAScClient} from "../../../../apiClient/apiClient";
import {IResult, IErrors} from "../../../../common/Interfaces";
import {getAuthClient} from "../../../../apiClient/getAuthClient";

export async function CHA2DS2VASResult(
    isInsult: boolean,
    isOld75: boolean,
    isOld65: boolean,
    isArterialHypertension: boolean,
    isDiabetes: boolean,
    isHeartFailure: boolean,
    isMyocardialInfarction: boolean,
    isWomen: boolean
) {
    let res: IResult<CHA2DS2VAScResponse> = {
        result: undefined,
        error: undefined,
    };

    try {
        let client = new CHA2DS2VAScClient(getAuthClient());
        res.result = await client.calculateCHA2DS2VASc(isInsult, isOld75, isOld65, isArterialHypertension, isDiabetes, isHeartFailure, isMyocardialInfarction, isWomen);

        return res;

    } catch (error) {
        res.error = <IErrors>JSON.parse(error.response);
        return res;
    }
}
