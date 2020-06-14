import {ScoreScaleResponse, ScoreScaleClient} from "../../../../apiClient/apiClient";
import {IResult, IErrors} from '../../../../common/Interfaces';
import {getAuthClient} from "../../../../apiClient/getAuthClient";

export async function ScoreResult(age: number, sad: number, plasmaCholesterol: number, isMen: boolean, isSmoke: boolean) {
    let res: IResult<ScoreScaleResponse> = {
        result: undefined,
        error: undefined
    };

    try {
        let client = new ScoreScaleClient(getAuthClient());
        res.result = await client.calculateScoreScale(age, sad, plasmaCholesterol, isMen, isSmoke);

        return res;

    } catch (error) {
        res.error = <IErrors>JSON.parse(error.response);
        return res;
    }
}