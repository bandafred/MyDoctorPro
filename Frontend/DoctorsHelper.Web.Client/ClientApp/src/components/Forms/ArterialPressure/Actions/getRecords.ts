import {DiaryClient} from "../../../../apiClient/apiClient";
import {getAuthClient} from "../../../../apiClient/getAuthClient";

export async function getRecords(fromDate: Date | undefined, toDate: Date | undefined) {
    try {
        let client = new DiaryClient(getAuthClient());
        return await client.getRecords(fromDate, toDate);
    } catch (error) {
        //notificate ?
    }
}