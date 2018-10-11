/**
 * Plain object to typed class object
 */
export interface Deserializable {
    /**
     * 
     * @param input The plain object that would like to be deserialized
     */
    deserialize(input: any): this;
}