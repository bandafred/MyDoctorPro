import {IndexSmokeResponse, IndexSmokeClient} from "../../../../apiClient/apiClient";
import {IResult, IErrors} from '../../../../common/Interfaces';
import {getAuthClient} from "../../../../apiClient/getAuthClient";


export async function IndexSmokeResult(ageSmoke: number, countSigar: number) {

    let res: IResult<IndexSmokeResponse> = {
        result: undefined,
        error: undefined
    };

    try {
        let client = new IndexSmokeClient(getAuthClient());
        res.result = await client.calculateIndexSmoke(ageSmoke, countSigar);

        return res;

    } catch (error) {
        res.error = <IErrors>JSON.parse(error.response);
        return res;
    }
}