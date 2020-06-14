import {IResult, IErrors} from "../../../../../common/Interfaces";
import {
    IndexSolovievaResponse,
    IndexSolovievaClient
} from "../../../../../apiClient/apiClient";
import {getAuthClient} from "../../../../../apiClient/getAuthClient";

export async function IndexSolovievaCalculate(
    isMan: boolean,
    wristLength: number
) {
    let res: IResult<IndexSolovievaResponse> = {
        result: undefined,
        error: undefined,
    };

    try {
        let client = new IndexSolovievaClient(getAuthClient());
        res.result = await client.calculateIndexSolovieva(isMan, wristLength);

        return res;

    } catch (error) {
        res.error = <IErrors>JSON.parse(error.response);
        return res;
    }
}

